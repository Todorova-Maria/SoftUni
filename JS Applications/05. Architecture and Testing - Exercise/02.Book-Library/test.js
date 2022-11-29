const { chromium } = require('playwright-chromium');
const { expect } = require('chai');
const { request } = require('http');
const { json } = require('stream/consumers');
const exp = require('constants');

const host = 'http://127.0.0.1:5500/02.Book-Library/index.html';

//info when press button loading // All books and theirs authors 
const mockData = {
    "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
        "author": "J.K.Rowling",
        "title": "Harry Potter and the Philosopher's Stone"
    },
    "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
        "author": "Svetlin Nakov",
        "title": "C# Fundamentals"
    }
};


describe('Tests', async function () {
    this.timeout(6000);

    let browser, page;

    before(async () => {
        browser = await chromium.launch({ headless: false, slowMo: 1000 });
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        page.close();
    });


    it('loads all books', async () => {
        //navigate to page  
        await page.goto(host);

        //find and click load button    
        await page.route('**/02.Book-Library/index.html', (route, request) => {
            route.fulfill({
                body: JSON.stringify({ mockData }),
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application'
                }
            });
        });


        await page.click('text = Load all books');
        await page.waitForSelector('text = Harry Potter');
        const rowData = await page.$$eval('tbody tr', rows => rows.map(r => r.textContent));

        //check that books are displayed 
        expect(rowData[0]).to.contains('Harry Potter');
        expect(rowData[0]).to.contains('Rowling');
        expect(rowData[1]).to.contains('C# Fundamentals');
        expect(rowData[1]).to.contains('Nakov');


    });

    it('create a book', async () => {
        //navigate to page
        await page.goto(host); 

        //fill input fields
        await page.fill('input[name=title]', 'Title');
        await page.fill('input[name=author]', 'Author'); 

        //click Submit
        const [request] = await Promise.all([
            page.waitForRequest((request) => request.method() == 'POST'), 
            page.click('text=Submit')
        ]);
        const data = JSON.parse(request.postData());
        expect(data.title).to.equal('Title'); 
        expect(data.author).to.equal('Author');
    });
});
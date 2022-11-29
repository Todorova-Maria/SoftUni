const expect =  require('chai').expect; 
const createCalculator = require('./07.Add-Subtract'); 

describe('Summator', () => {
    let instance = null; 

    beforeEach(() => {
        instance = createCalculator();
    });

    it('has all methods', () => {
        expect(instance).to.have.ownProperty('add');
        expect(instance).to.have.ownProperty('subtract');
        expect(instance).to.have.ownProperty('get');
    });

    it('add one number correctly', () => {
        instance.add(5); 
        expect(instance.get()).to.equal(5); 
    });

    it('add more numbers correctly', () => {
        instance.add(5); 
        instance.add(5); 
        expect(instance.get()).to.equal(10); 
    });

    it('subtract one number correctly', () => {
        instance.subtract(5); 
        expect(instance.get()).to.equal(-5);
    });

    it('subtract more numbers correctly', () => {
        instance.subtract(5); 
        instance.subtract(2); 
        expect(instance.get()).to.equal(-7);
    });

    it('add and subtract correctly', () => {
        instance.add(3); 
        instance.subtract(2); 
        expect(instance.get()).to.equal(1); 
    });
    it('starts empty', () => {
        expect(instance.get()).to.equal(0);
    });
    it('works with numbers as strings', () => {
        instance.add('4'); 
        expect(instance.get()).to.equal(4);
    });

})
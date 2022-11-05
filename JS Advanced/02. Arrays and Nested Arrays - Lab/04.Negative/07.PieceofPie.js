function solve(input, startWord, endWord) {
    const start = input.indexOf(startWord);  
    const end = input.indexOf(endWord); 

    const result = input.slice(start, end + 1); 
    return result; 
}
console.log(solve(['Pumpkin Pie', 'Key Lime Pie', 'Cherry Pie', 'Lemon Meringue Pie', 'Sugar Cream Pie'], 
'Key Lime Pie',
'Lemon Meringue Pie'
));

function solve(matrix) {
let count = 0; 

const rowSize = matrix[0].length;
// check rows
for (let row = 0; row < matrix.length; row++) {
for (let col = 0; col < matrix[row].length - 1; col++) {

    if(matrix[row][col] === matrix[row][col + 1]){
    count++;
    }        
                  
        }
    }



// check columns 
for (let col = 0; col < rowSize; col++) {
for (let row = 0; row < matrix.length - 1; row++) {

    if(matrix[row][col] === matrix[row + 1][col]) {
        count++; 
    } 
    }
}
console.log(count);
}

solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]
);

solve([['test', 'yes', 'yo', 'ho'],
 ['well', 'done', 'yo', '6'],
 ['not', 'done', 'yet', '5']]); 


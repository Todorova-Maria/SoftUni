function solve(input) {
    const result = []; 

    input.sort((a,b) => a - b);

    
    for( let i = Math.floor(input.length / 2); i < input.length; i++) {
        result.push(input[i]);
        }
        return result; 
}

console.log(solve([4, 7, 2, 5]));

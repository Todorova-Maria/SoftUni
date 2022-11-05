function solve(input) {
   const odd = input.filter((x,i) => i % 2); 
   const doubled = odd.map(x => x*2); 
   doubled.reverse(); 

   console.log(doubled.join(' '));
}
solve([10, 15, 20, 25]); 
solve([3, 0, 10, 4, 7, 3]); 
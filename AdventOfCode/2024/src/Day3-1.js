const input = prompt("puzzle input plz:");

let total =0;
const mulMatch = new RegExp('mul\\(\\d{1,3},\\d{1,3}\\)','g');
const numMatch = new RegExp('\\d{1,3}','g');

let matches = input.match(mulMatch);
matches.forEach((match)=>{
    let base = 1;
    match.match(numMatch).map(x=>base*=x);
    total+=base;
})

alert(total);


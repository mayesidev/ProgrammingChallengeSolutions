const input = prompt("puzzle input plz:");

const leftList = [];
const rightList = [];

const lines = input.split("\n");
lines.forEach((line)=>
{
    let vals = line.split("   ");
    leftList.push(vals[0]);
    rightList.push(vals[1]);
});

leftList.sort();
rightList.sort();

let total = 0;
for(let i = 0; i<leftList.length; i++){
    total += Math.abs(leftList[i] - rightList[i]);
}

alert(total);

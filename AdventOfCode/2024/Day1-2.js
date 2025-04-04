const input = prompt("puzzle input plz:");

const leftList = [];
const locationCounts = new Map();

const lines = input.split("\n");
lines.forEach((line)=>
{
    let vals = line.split("   ");
    leftList.push(vals[0]);

    let foundVal = locationCounts.get(vals[1]);
    if(foundVal != undefined){
        locationCounts.set(vals[1], foundVal+1);
    }
    else{
        locationCounts.set(vals[1], 1);
    }
});

let total = 0;
for(let i = 0; i<leftList.length; i++){
    let foundCount = locationCounts.get(leftList[i]);
    if(foundCount==undefined)
    {
        foundCount=0;
    }
    total += leftList[i] * foundCount;
}

alert(total);


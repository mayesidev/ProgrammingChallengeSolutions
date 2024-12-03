const input = prompt("puzzle input plz:");

let safeCount = 0;

const lines = input.split("\n");
lines.forEach((line)=>
{
    let vals = line.split(" ").map(Number);
    let lineIncreasing = null;
    let isSafe = true;
    for(let i=1; i<vals.length; i++)
    {
        if(isSafe)
        {
            let val = vals[i];
            let previousVal = vals[i-1];
            let valDiff = val - previousVal;
            if(lineIncreasing === null)
            {
                lineIncreasing = valDiff > 0;
            }

            if(lineIncreasing !== null)
            {
                let increasing = lineIncreasing && val>previousVal;
                let decreasing = !lineIncreasing && val<previousVal;
                let safeDirection = increasing||decreasing;
                let increment = Math.abs(valDiff);
                let safeIncrement = increment<4 && increment>0;

                isSafe = safeDirection && safeIncrement;

                // console.log("val:" + val);
                // console.log("pVal:" + previousVal);
                // console.log("line:" + lineIncreasing);
                // console.log("incStep:" + val>previousVal);
                // console.log("inc:" + increasing);
                // console.log("decStep:" + val<previousVal);
                // console.log("dec:" + decreasing);
                // console.log("sDir:" + safeDirection);
                // console.log("step:" + increment);
                // console.log("sStep:" + safeIncrement);
                // console.log("safe:" + isSafe);
                // console.log("----------");

                if(isSafe && i===vals.length-1){
                    safeCount++;
                    console.log("go next")
                }
            }
        }
        else{
            console.log("unsafe-skipping rest of line")
        }
    }
});

console.log("answer: " + safeCount);

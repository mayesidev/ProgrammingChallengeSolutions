const input = prompt("puzzle input plz:");

let total =0;
let doMult = true;
const mulMatch = new RegExp('mul\\(\\d{1,3},\\d{1,3}\\)','g');
const doMatch = new RegExp('do\\(\\)','g');
const dontMatch = new RegExp('don\'t\\(\\)','g')
const numMatch = new RegExp('\\d{1,3}','g');
let lastIndex = 0;

let dontSegments = input.split(dontMatch);
dontSegments.forEach((dontSegment)=>{
    console.log("do- " + dontSegment)
    let doSegments = dontSegment.split(doMatch);
    doSegments.forEach((doSegment)=>{
        console.log("dont- "+doSegment)
    })

    // if(doMult){
    //     let matches = segment.match(mulMatch);
    //     matches.forEach((match)=>{
    //         let base = 1;
    //         match.match(numMatch).map(x=>base*=x);
    //         total+=base;
    //     })
    // }
    // doMult = false;
}
)

alert(total);


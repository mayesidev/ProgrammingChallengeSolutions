const input = prompt("puzzle input plz:");
let inputGrid = [];

const lines = input.split("\n");
for(let i=0; i<lines.length; i++)
{
    inputGrid[i] = []
    for(let j=0; j<lines[i].length; j++){
        inputGrid[i][j] = lines[i].charAt(j);
    }
}

let xmasFound = 0;
for(let l = 0; l<inputGrid.length; l++){
    for(let h = 0; h < inputGrid[l].length; h++){

        //ms
        //a
        //ms
        try{
            if(inputGrid[l][h]==='A'
                && inputGrid[l-1][h-1]==='M'
                && inputGrid[l+1][h+1]==='S'
                && inputGrid[l+1][h-1]==='M'
                && inputGrid[l-1][h+1]==='S'){
                xmasFound++;
            }
        }catch{}

        //sm
        //a
        //sm
        try{
            if(inputGrid[l][h]==='A'
                && inputGrid[l-1][h-1]==='S'
                && inputGrid[l+1][h+1]==='M'
                && inputGrid[l+1][h-1]==='S'
                && inputGrid[l-1][h+1]==='M'){
                xmasFound++;
            }
        }catch{}

        //mm
        //a
        //ss
        try{
            if(inputGrid[l][h]==='A'
                && inputGrid[l-1][h-1]==='M'
                && inputGrid[l+1][h+1]==='S'
                && inputGrid[l+1][h-1]==='S'
                && inputGrid[l-1][h+1]==='M'){
                xmasFound++;
            }
        }catch{}

        //ss
        //a
        //mm
        try{
            if(inputGrid[l][h]==='A'
                && inputGrid[l-1][h-1]==='S'
                && inputGrid[l+1][h+1]==='M'
                && inputGrid[l+1][h-1]==='M'
                && inputGrid[l-1][h+1]==='S'){
                xmasFound++;
            }
        }catch{}
    }
}

console.log(xmasFound);
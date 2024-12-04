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
        if(inputGrid[l][h]==='X'
            && inputGrid[l][h+1]==='M'
            && inputGrid[l][h+2]==='A'
            && inputGrid[l][h+3]==='S'){
                console.log("forward")
                xmasFound++;
        }

        if(inputGrid[l][h]==='X'
            && inputGrid[l][h-1]==='M'
            && inputGrid[l][h-2]==='A'
            && inputGrid[l][h-3]==='S'){
                console.log("backward")
                xmasFound++;
        }

        try{
            if(inputGrid[l][h]==='X'
                && inputGrid[l+1][h]==='M'
                && inputGrid[l+2][h]==='A'
                && inputGrid[l+3][h]==='S'){
                    console.log("down");
                    xmasFound++;
            }
        }catch{}

        try{
            if(inputGrid[l][h]==='X'
                && inputGrid[l-1][h]==='M'
                && inputGrid[l-2][h]==='A'
                && inputGrid[l-3][h]==='S'){
                    console.log("up");
                    xmasFound++;
            }
        }catch{}

        try{
            if(inputGrid[l][h]==='X'
                && inputGrid[l+1][h+1]==='M'
                && inputGrid[l+2][h+2]==='A'
                && inputGrid[l+3][h+3]==='S'){
                    console.log("forward-down");
                    xmasFound++;
            }
        }catch{}

        try{
            if(inputGrid[l][h]==='X'
                && inputGrid[l+1][h-1]==='M'
                && inputGrid[l+2][h-2]==='A'
                && inputGrid[l+3][h-3]==='S'){
                    console.log("backward-down");
                    xmasFound++;
            }
        }catch{}

        try{
            if(inputGrid[l][h]==='X'
                && inputGrid[l-1][h-1]==='M'
                && inputGrid[l-2][h-2]==='A'
                && inputGrid[l-3][h-3]==='S'){
                    console.log("backward-up");
                    xmasFound++;
            }
        }catch{}

        try{
            if(inputGrid[l][h]==='X'
                && inputGrid[l-1][h+1]==='M'
                && inputGrid[l-2][h+2]==='A'
                && inputGrid[l-3][h+3]==='S'){
                    console.log("forward-up");
                    xmasFound++;
            }
        }catch{}
    }
}

console.log(xmasFound);
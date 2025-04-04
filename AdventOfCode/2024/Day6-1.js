// x,y in this code are actually -y,x since we're starting with 0,0 in the top left and working over then down when building the array...
const input = prompt("puzzle input plz:");
let inputGrid = [];
let startPosition = [0,0];
const lines = input.split("\n");
for(let x=0; x<lines.length; x++)
{
    inputGrid[x] = []
    for(let y=0; y<lines[x].length; y++){
        inputGrid[x][y] = lines[x].charAt(y);

        if(inputGrid[x][y]==='^'){
            startPosition = [x,y];
        }
    }
}

let spacesVisited = 0;
let onGrid = true;
let direction = 0;
let currentX = startPosition[0];
let currentY = startPosition[1];

try{
while(onGrid){    
    // console.log("currentDirection: "+direction);
    // console.log("currentX: "+currentX);
    // console.log("currentY: "+currentY);
    let nextStep = calcNextCoord(direction%4,currentX,currentY)
    let nextX = nextStep[0];
    let nextY = nextStep[1];
    if(nextX < 0
        || nextY < 0
        ||nextX>=inputGrid.length
        || nextY>=inputGrid[0].length){
        spacesVisited++;
        onGrid=false;
    }
    else if(inputGrid[nextX][nextY]==='#')
    {
        direction++;
    }
    else{
        if(inputGrid[currentX][currentY]!=='X'){
            inputGrid[currentX][currentY]='X';
            spacesVisited++;
        }
        currentX=nextX;
        currentY=nextY;
    }
    // console.log("nextDirection: "+direction);
    // console.log("nextX: "+nextX);
    // console.log("nextY: "+nextY);
}
}
catch{}
finally{
    console.log("last X,Y: "+currentX+","+currentY);
    console.log(spacesVisited);
}

function calcNextCoord(direction, xIndex, yIndex){
    switch (direction){
        case 0: //up
            xIndex--;
            break;
        case 1: //right
            yIndex++;
            break;
        case 2: //down
            xIndex++;
            break;
        case 3: //left
            yIndex--;
            break;
        default:
            console.log("oops");
    }
    return [xIndex,yIndex];
}

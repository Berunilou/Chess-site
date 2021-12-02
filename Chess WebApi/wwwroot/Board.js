var divSquares = ``;

function Board() {
    for (var x = 0; x < 8; x++)
        for (var y = 7; y >= 0; y--)
            if ((x + y) % 2 == 0)
                divSquares += `<div id=${x}${y} class="square black"></div>`;
            else
                divSquares += `<div id=${x}${y} class="square white"></div>`;
    document.getElementById("Board").innerHTML = divSquares;

    PasteFigure();
}

Board();

function PasteFigure()
{

}
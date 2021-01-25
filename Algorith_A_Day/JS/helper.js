let matrix = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];

//5 is the number of rows and 4 is the number of columns.
const matrix2 = new Array(5).fill(0).map(() => new Array(4).fill(0));

let Array2D = (r, c) => [...Array(r)].map(x => Array(c).fill(0));

let m = Array2D(3, 5);

let m4 = new Array(4);
for (let i = 0; i < m4.length; i++) {
    m4[i] = new Array(3);
}


function spiralOrder(matrix) {
    let result = [];
    if (matrix === null || matrix.length === 0) return result;

    let currentRow = 0;
    let currentColumn = 0;
    let lastRow = matrix.length - 1;
    let lastColumn = matrix[0].length - 1;

    while (currentRow <= lastRow && currentColumn <= lastColumn) {

        for (let i = currentColumn; i <= lastColumn; i++) {
            result.push(matrix[currentRow][i]);
        };
        currentRow++;

        for (let i = currentRow; i <= lastRow; i++) {
            result.push(matrix[i][lastColumn]);
        };
        lastColumn--;

        if (currentRow <= lastRow) {
            for (let i = lastColumn; i >= currentColumn; i--) {
                result.push(matrix[lastRow][i]);
            };
            lastRow--;
        };
        
        if (currentColumn <= lastColumn) {
            for (let i = lastRow; i >= currentRow; i--) {
                result.push(matrix[i][currentColumn]);
            };
            currentColumn++;
        }; 
    }
    return result;
    
}

var singleNumber = function (nums) {
    if (nums === null) return -1;

    let dict = {};

    for (let num of nums) {
        if (!dict.num === null) {
            dict.num++;
        }
        else {
            dict[num] = 1;
        }
    }

    for (var kv in dict) {
        if (dict[kv] === 1) {
            return kv;
        }
    }
    return -1;
};


// search for minimal and delete until find kth smallest
numbers = [3, 2, 55, -10, -55, 5, 3, 2, 1, -5, 33, 9, -1, 4, 5];

function FindSmallestNumber(arr, limit) {
    var min = '';
    for (var counter = 1; counter <= limit; counter++) {
        min = Math.min.apply(Math, arr);
        arr.splice(arr.indexOf(min), 1);
    }
    console.log(min);
}

FindSmallestNumber(Numbers, 3); //3rd smallest number
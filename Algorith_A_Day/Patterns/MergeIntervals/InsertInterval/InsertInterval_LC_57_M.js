    var insert = function(intervals, newInterval) {
    // return list of list with newInterval
        if(intervals.length == 0) return [newInterval];

        // insert new interval in correct location
        const output = [];
    let pushed = false;

        for(const i of intervals){
            // check only first numbers as we gonna mergr them anyway
            if(!pushed && newInterval[0] < i[0]){
                output.push(newInterval);
                pushed = true;
            }
output.push(i);
        }

    //for input [[1,5]] , [2,7] expected is [1,7] so we need to:
    // if new interval is not pushed we need to push it here:
    if (!pushed) output.push(newInterval);


// merge intervals along with push newInterval
// this is the same as mergeintervals 56
return mergeIntervals(output);
};

var mergeIntervals = (intervals) => {
    //normallly it shoul be sorted but it is sorted in that case
    const output = [];

    let candidateInterval = intervals[0];


    for (let i = 1; i < intervals.length; i++)
    {
        const currentInterval = intervals[i];

        if (currentInterval[0] <= candidateInterval[1])
        {
            candidateInterval[1] = Math.max(candidateInterval[1], currentInterval[1]);
        }
        else
        {
            output.push(candidateInterval);
            candidateInterval = currentInterval;
        }
    }


    output.push(candidateInterval);


    return output;
};
fetch("Day7_input.txt")
    .then((response) => response.text())
    .then((data) => {
        let list = data.split(",");
        let listSums = new Array(Math.max(...list) + 1).fill(0);
        for (let i = 0; i < list.length; i++) {
            listSums[list[i]]++;
        }
        let minCost = Number.MAX_SAFE_INTEGER;
        for (let targetPos = 0; targetPos < listSums.length; targetPos++) {
            let targetCost = 0;
            for (let startPos = 0; startPos < listSums.length; startPos++) {
                let value = 0;
                for (let i = 0; i < Math.abs(targetPos - startPos); i++) {
                    value += i + 1;
                }
                targetCost += value * listSums[startPos];
            }
            minCost = targetCost < minCost ? targetCost : minCost;
        }
        console.log(minCost);
    });
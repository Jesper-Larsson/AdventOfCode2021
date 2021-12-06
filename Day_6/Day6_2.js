fetch("Day6_input.txt")
    .then((response) => response.text())
    .then((data) => {
        let list = data.split(",");
        let listSums = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        for (let i = 0; i < list.length; i++) {
            listSums[list[i]]++;
        }
        for (let i = 0; i < 256; i++) {
            nrOfNewFish = listSums[0];
            for (let i = 0; i < 8; i++) {
                listSums[i] = listSums[i + 1];
            }
            listSums[6] += nrOfNewFish;
            listSums[8] = nrOfNewFish;
        }
        let nrOfFishTotal = 0;
        listSums.forEach((fishSum) => {
            nrOfFishTotal += fishSum;
        });
        console.log(nrOfFishTotal);
    });
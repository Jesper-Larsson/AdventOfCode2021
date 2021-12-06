fetch("Day6_input.txt")
    .then((response) => response.text())
    .then((data) => {
        let list = data.split(",");
        for (let i = 0; i < 80; i++) {
            for (let i = 0; i < list.length; i++) {
                if (list[i] == 0) {
                    list[i] = 7;
                    list.push(9);
                }
                list[i]--;
            }
        }
        console.log(list.length);
    });
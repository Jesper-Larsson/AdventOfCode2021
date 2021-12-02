fetch("Day2_1.txt")
    .then((response) => response.text())
    .then((data) => {
        let hPos = 0;
        let vPos = 0;
        const lines = data.split("\n");
        lines.forEach((line) => {
            const lineContent = line.split(" ");
            switch (lineContent[0]) {
                case "forward":
                    hPos += parseInt(lineContent[1]);
                    break;
                case "down":
                    vPos += parseInt(lineContent[1]);
                    break;
                case "up":
                    vPos -= parseInt(lineContent[1]);
            }
        });
        console.log(hPos * vPos);
    });
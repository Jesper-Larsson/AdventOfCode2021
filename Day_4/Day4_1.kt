import java.io.File
import java.io.InputStream
import java.util.*

fun main(args: Array<String>) {
    val stream: InputStream = File("Day4_input.txt").inputStream();
    val allLines = stream.bufferedReader().readLines();
    var itr = allLines.iterator();
    val drawnNrs = itr.next().split(",");
    val boardList = ArrayList<BingoBoard>();
    while(itr.hasNext()){
        itr.next();
        val bingoBoard = Array(5) { IntArray(5) }
        for(i in 0..bingoBoard.size-1) {
            val list = itr.next().replace("  ", " ").trim().split(" ");
            for (j in 0..list.size-1) {
                bingoBoard[i][j] = list[j].toInt();
            }
        }
        boardList.add(BingoBoard(bingoBoard));
    }
    drawnNrs.forEach { number ->
        boardList.forEach { board ->
            if(board.checkBingo(number.toInt())){
                println(board.getScore(number.toInt()));
                return;
            }
        }
    }
}


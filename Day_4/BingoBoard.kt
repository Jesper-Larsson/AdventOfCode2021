class BingoBoard(board: Array<IntArray>){
    val boardNumbers = board;
    var placesChecked = Array(board.size) { BooleanArray(board[0].size) };
    var isDone = false;
    fun checkBingo(numberToCheck: Int): Boolean{
        for(rowNum in 0..boardNumbers.size-1){
            for(colNum in 0..boardNumbers[0].size-1){
                //println("check: " + numberToCheck + " found:  " + boardNumbers[rowNum][colNum])
                if(boardNumbers[rowNum][colNum] == numberToCheck){
                    return isBingo(rowNum, colNum);
                }
            }
        }
        return false;
    }
    fun isBingo(rowNum: Int, colNum: Int): Boolean{
        placesChecked[rowNum][colNum] = true;
        for (i in placesChecked.indices){
            if(!placesChecked[i][colNum]){break}
            else if(i == placesChecked.size-1){
                isDone = true;
                return true;
            }
        }
        for (i in placesChecked[0].indices){
            if(!placesChecked[rowNum][i]){break}
            else if(i == placesChecked[0].size-1){
                isDone = true;
                return true;
            }
        }
        return false;
    }
    fun getScore(number:Int): Int{
        var uncheckedSum = 0;
        for(row in boardNumbers.indices)
            for(col in boardNumbers[0].indices){
                if(!placesChecked[row][col]){
                    uncheckedSum += boardNumbers[row][col];
                }
            }
        return uncheckedSum * number;
    }
}
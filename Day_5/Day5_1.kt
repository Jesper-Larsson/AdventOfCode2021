import java.io.File
import java.io.InputStream
import java.util.Collections.max

fun main(args: Array<String>){
    val stream: InputStream = File("Day5_input.txt").inputStream();
    val inputLines = stream.bufferedReader().readLines();
    val allLines = Array(inputLines.size) { IntArray(4) };
    for(i in allLines.indices){
        allLines[i] = inputLines[i].replace(" -> ", ",").split(",").map { it.toInt() }.toIntArray();
    }
    val yMax = max(allLines.map{ kotlin.math.max(it[2],it[3])+1})
    val xMax = max(allLines.map{ kotlin.math.max(it[0],it[2])+1});
    val lineMap = Array(yMax) {IntArray (xMax) };
    for(i in allLines.indices){
        if(allLines[i][0]==allLines[i][2]
            || allLines[i][1]==allLines[i][3]){
            var row = allLines[i][1];
            var col = allLines[i][0];
            while(row != allLines[i][3]){
                lineMap[row][col]++;
                row = if (allLines[i][3]>row) row+1 else row-1;
            }
            while(col != allLines[i][2]){
                lineMap[row][col]++;
                col = if (allLines[i][2]>col) col+1 else col-1;
            }
            lineMap[row][col]++;
        }
    }
    var nrOfOvelaps = 0;
    lineMap.forEach { line-> line.forEach { cell -> if (cell >=2) nrOfOvelaps++ } }
    println(nrOfOvelaps);
}
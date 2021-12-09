package Day_9

import java.io.File
import java.io.InputStream
import java.util.Collections.max

fun main(args: Array<String>){
    val stream: InputStream = File("Day9_input.txt").inputStream();
    val inputLines = stream.bufferedReader().readLines().map(){ str -> str.toCharArray().map { ch -> ch.toString().toInt() }};
    var visitedPlaces = Array(inputLines.size){ BooleanArray(inputLines[0].size)}
    val basins = ArrayList<Int>(0);
    for(row in inputLines.indices){
        for (col in inputLines[0].indices){
            if(!visitedPlaces[row][col]){
                var basinSize = step(inputLines, visitedPlaces, row, col)
                basins.add(basinSize);
                //println("new basin" + basinSize);
            }
        }
    }
    val arr = basins.sortedDescending()
    println(arr[0]*arr[1]*arr[2])


}

fun step(input:List<List<Int>>, visited : Array<BooleanArray>, row: Int, col: Int) : Int{
    //println("step");
    if(row > -1 && row < input.size && col > -1 && col < input[0].size && !visited[row][col]){
        visited[row][col] = true;
        if(input[row][col]== 9){
            return 0;
        }
        return step(input, visited, row-1, col) +
                step(input, visited, row+1, col) +
                step(input, visited, row, col+1) +
                step(input, visited, row, col-1) + 1;
    }
    //println("returning")
    return 0;
}
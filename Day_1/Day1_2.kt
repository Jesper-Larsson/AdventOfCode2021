import java.io.File
import java.io.InputStream

fun main(args: Array<String>) {
    var nrOfDepthInc = 0;
    val allDepthsList = mutableListOf<Int>();
    val stream : InputStream = File("Day1_1.txt").inputStream();
    stream.bufferedReader().forEachLine {
            allDepthsList.add(it.toInt());
    }
    var startIndex = 0;
    while (startIndex < allDepthsList.size-3){
        var firstSum = allDepthsList[startIndex]
        var secondSum = allDepthsList[startIndex+1]
        for (i in 1..2){
            firstSum += allDepthsList[startIndex+i]
            secondSum +=allDepthsList[startIndex+i+1]
        }
        if(secondSum > firstSum){
            nrOfDepthInc++;
        }
        startIndex++;
    }
    println(nrOfDepthInc);
}

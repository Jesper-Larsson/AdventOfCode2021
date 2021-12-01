import java.io.File
import java.io.InputStream

fun main(args: Array<String>) {
    val stream : InputStream = File("Day1_1.txt").inputStream();
    var nrOfDepthInc = 0;
    var prevDepth = -1;
    stream.bufferedReader().forEachLine {
        if (prevDepth == -1 ){
            prevDepth = it.toInt();
        } else{
            var newDepth = it.toInt();
            if(newDepth > prevDepth){
                nrOfDepthInc++;
            }
            prevDepth = newDepth;
        }
    }
    println(nrOfDepthInc);


}
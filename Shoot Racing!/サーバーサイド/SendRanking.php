<?php
require_once("./ConnectDB.php");
$pdo = connectDB();

try{
    $sql = "SELECT DISTINCT user_name,score FROM ranking_table ORDER BY score ASC LIMIT 30";
    $stmt = $pdo->prepare($sql);
    $stmt->execute();

    foreach($stmt as $row){
        $res = $row["user_name"];
        $res = $res . "," . $row["score"] . ",";
        echo $res;
    }
}catch(PDOException $e){
    var_dump($e->getMessage());
}
$pdo = null;

?>
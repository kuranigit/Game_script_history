<?php
require_once("./ConnectDB.php");
$pdo = connectDB();

$score = $_POST["score"];
$user_name = $_POST["user_name"];

try{
    //ユーザーデータ挿入
    $sql = "INSERT INTO ranking_table (user_name,score) VALUES (:name,$score)";
    $stmt = $pdo->prepare($sql);
    $stmt->bindValue(":name",$user_name);
    $stmt->execute();

    //名前が重複しているレコード中ハイスコア以外の物を削除
    $sql = "DELETE FROM ranking_table WHERE (user_name, score) NOT IN 
    (SELECT user_name,min_score FROM (SELECT user_name, MIN(score) AS min_score FROM ranking_table GROUP BY user_name) AS tmp)";
    $stmt = $pdo->prepare($sql);
    $stmt->execute();

}catch(PDOException $e){
    var_dump($e->getMessage());
}
$pdo = null;

?>
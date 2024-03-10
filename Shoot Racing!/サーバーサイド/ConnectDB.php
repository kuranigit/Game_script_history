<?php
function connectDB(){
    $servername = "";  // サーバー名
    $dbname = "";  // データベース名
    $username = "";  // ユーザー名
    $password = "";  // パスワード

    try {
        // データベースに接続
        $pdo = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    } catch (PDOException $e) {
        //エラー表示
        exit(" " . $e->getMessage());
    }

    return $pdo;
}

?>

<?php

require_once 'config.php';

if ($_SERVER['REQUEST_METHOD'] == 'GET') {

    $sql = "SELECT * FROM varian";
    $res = mysqli_query($koneksi, $sql);
    $result = array();

    while ($row = mysqli_fetch_array($res)) {
        array_push($result, array('id' => $row[0], 'jenis_varian' => $row[1], 'versi_varian' => $row[2], 'tanggal' => $row[3], 'negara' => $row[4], 'gejala' => $row[5], 'audio' => $row[6]));
    }

    echo json_encode(array("listData" => "varian", "result" => $result));
    mysqli_close($koneksi);
}

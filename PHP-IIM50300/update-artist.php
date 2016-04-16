<?php
session_start();
// abook-lisaa.php
include ("header.php");
require_once("db-init-music.php");

 
$nimi   = isset($_POST['nimi'])   ? $_POST['nimi']   : '';
$vuosi = isset($_POST['vuosi']) ? $_POST['vuosi'] : '';
$maa  = isset($_POST['maa'])  ? $_POST['maa']  : '';
$id = $_POST['id'];


$sql = <<<SQLEND
UPDATE esittaja 
SET nimi = ?, 
maa_avain = (SELECT avain from maa WHERE nimi = ?), 
vuosi_avain = (SELECT avain from vuosi WHERE vuosi = ?)
WHERE avain = ?
SQLEND;
 
$stmt = $conn->prepare("$sql");
$stmt-> bind_param('ssii', $nimi, $maa, $vuosi, $id);

$stmt->execute();
printf("%d Rivi muutettiin.\n", $stmt->affected_rows);
include ("footer.php");
?>

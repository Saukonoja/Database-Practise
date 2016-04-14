<?php
session_start();
// abook-lisaa.php
include ("header.php");
require_once("db-init-music.php");
 
$nimi   = isset($_REQUEST['nimi'])   ? $_REQUEST['nimi']   : '';
$vuosi = isset($_REQUEST['vuosi']) ? $_REQUEST['vuosi'] : '';
$maa  = isset($_REQUEST['maa'])  ? $_REQUEST['maa']  : '';


$sql = <<<SQLEND
INSERT INTO esittaja (nimi, maa_avain, vuosi_avain)
VALUES(?,(SELECT avain FROM maa WHERE nimi = ?),(SELECT avain FROM vuosi WHERE vuosi = ?))
SQLEND;
 
$stmt = $conn->prepare("$sql");
$stmt-> bind_param('ssi', $nimi, $maa, $vuosi);

$stmt->execute();
printf("%d Rivi lisättiin.\n", $stmt->affected_rows);
include ("footer.php");
?>
<?php
session_start();
// abook-lisaa.php
include ("header.php");
require_once("db-init-music.php");
 
$nimi   = 'testi';


$sql = <<<SQLEND
DELETE FROM esittaja WHERE nimi = (?)
SQLEND;
 
$stmt = $conn->prepare("$sql");
$stmt-> bind_param('s', $nimi);

$stmt->execute();
printf("%d Rivi poistettiin.\n", $stmt->affected_rows);
include ("footer.php");
?>
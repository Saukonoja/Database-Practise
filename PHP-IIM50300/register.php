<?php
session_start();
// abook-lisaa.php
include ("header.php");
require_once("db-init-music.php");
 
$username   = isset($_REQUEST['username'])   ? $_REQUEST['username']   : '';
$password = isset($_REQUEST['password']) ? $_REQUEST['password'] : '';

$sql = <<<SQLEND
INSERT INTO user (tunnus, salasana, tyyppi)
VALUES(?,?,0)
SQLEND;
 
$stmt = $conn->prepare("$sql");
$stmt-> bind_param('ss', $username, $password);

$stmt->execute();
printf("%d Rivi lisättiin.\n", $stmt->affected_rows);
include ("footer.php");
?>
<?php
session_start();
include ("header.php"); 
$errmsg = '';
if(isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}
if (isset($_POST['nimi']) AND isset($_POST['vuosi']) AND isset($_POST['maa'])){
require_once("db-init-music.php");

$nimi   = $_POST['nimi'];
$vuosi = $_POST['vuosi'];
$maa  = $_POST['maa'];

include("insert-queries/insert-artist.php");
 
$stmt = $conn->prepare("$sql");
$stmt-> bind_param('ssi', $nimi, $maa, $vuosi);

$stmt->execute();
printf("%d Rivi lisättiin.\n", $stmt->affected_rows);
}
?>
<?php include ("footer.php"); ?>

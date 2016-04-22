<?php
include ("../Init/header.php");

require_once($dbInit);


 
if ($_POST['action'] == 'Save changes'){


	if (!empty($_POST['nimi']) AND !empty($_POST['esittaja']) AND !empty($_POST['vuosi']) AND !empty($_POST['vuosi']) AND !empty($_POST['cd']) AND 
		!empty($_POST['genre']) AND !empty($_POST['number']) AND !empty($_POST['length'])){
		$name     = isset($_POST['nimi'])   ? $_POST['nimi']   : '';
		$artist     = isset($_POST['esittaja'])   ? $_POST['esittaja']   : '';
		$year     = isset($_POST['vuosi']) ? $_POST['vuosi'] : '';
		$album  = isset($_POST['cd'])  ? $_POST['cd']  : '';
		$genre  = isset($_POST['genre'])  ? $_POST['genre']  : '';
		$tubelink  = isset($_POST['tube']) ? $_POST['tube'] : '';
		$number   = $_POST['number'];
		$length   = $_POST['length'];
		$id       = $_POST['id'];

		if (preg_match('/=/',$tubelink)){
			$tubeparsed = substr($tubelink, strpos($tubelink, "=") + 1);
		}else{
			$tubeparsed = $tubelink;
		}
		

		$sql = "UPDATE kappale 
                                 SET nimi = ?,
                                 esittaja_avain = (SELECT avain FROM esittaja WHERE nimi = ?),
                                 vuosi_avain = (SELECT avain FROM vuosi WHERE vuosi = ?),
                                 tubepath = ?, 
                                 numero = ?, 
                                 kesto = ? 
                                 WHERE avain = ?;";

        $sql1 =   "UPDATE cd_kappale 
                                 SET cd_avain = (SELECT avain FROM cd WHERE nimi = ?) 
                                 WHERE kappale_avain = ?;";          

        $sql2 = "UPDATE kappale_genre 
                                 SET genre_avain = (SELECT avain FROM genre where nimi = ?) 
                                 WHERE kappale_avain = ?;";                                      
		 
		$stmt = $conn->prepare($sql);
		$stmt->bind_param('ssisiss', $name, $artist, $year, $tubeparsed, $number, $length, $id);
		$stmt->execute();
		$stmt = $conn->prepare($sql1);
		$stmt->bind_param('si', $album, $id);
		$stmt = $conn->prepare($sql2);
		$stmt->bind_param('si', $genre, $id);

		if ($stmt->execute()){
			echo "<h2>Track updated to database.</h2>";
			echo "<script>setTimeout(\"location.href = 'Tracks.php';\",1000);</script>";
		} else{
			echo "<script>alert('There was an error during updating.'); setTimeout(\"location.href = '".$updateTrackForm."';\",0);</script>";
		}
	}else{
		echo "<script>alert('Fill fields first.'); setTimeout(\"location.href = '".$updateTrackForm."';\",0);</script>";
	}

} else if ($_POST['action'] == 'Delete track'){

	$id = $_POST['id'];

	$sql = "DELETE FROM kappale_genre WHERE kappale_avain = ?";
	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('s', $id);
	$stmt->execute();
	$sql = "DELETE FROM cd_kappale WHERE kappale_avain = ?";
	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('s', $id);
	$stmt->execute();
	$sql = "DELETE FROM kappale WHERE avain = ?";
	$stmt = $conn->prepare("$sql");
	$stmt-> bind_param('s', $id);

	if ($stmt->execute()){
		echo "<h2>Track deleted from the database.</h2>";
		echo "<script>setTimeout(\"location.href = '".$tracks."';\",1000);</script>";
	} else{
		echo "<script>alert('There was an error during deletion.'); setTimeout(\"location.href = '".$updateTrackForm."';\",0);</script>";
	}

}

include ($footer);

?>
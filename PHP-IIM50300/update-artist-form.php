<?php 

session_start();

require_once("db-init-music.php");

if (isset($_POST['ID'])){
  $_SESSION['id'] = $_POST['ID'];
}

include("select-queries/artist-update-form-query.php");

include ("header.php"); 

$result = $conn->query("$sql");

if ($row = $result->fetch_assoc()){
	$form = <<<FORMEND
  
    <form action='Artists.php'><button id='btnBack' class='buttons'><i id="backIcon" class="fa fa-arrow-left fa-lg"></i></button></form>
    <div id=updateForm>
      <h1>Update artist</h1>
      <form method='post' action='update-artist.php'>
          <table border='0' cellpadding='5'>
            <tr id='hiddenTr' valign='top'>
              <td align='right'>ID</td>
              <td>{$row['id']}<input type='hidden' name='id' size='30' value='{$row['id']}'></td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Name</td>
              <td><input type='text' name='nimi' size='30' value='{$row['nimi']}'></td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Year</td>
              <td><input type='text' name='vuosi' size='30' value='{$row['vuosi']}'></td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Country</td>
              <td><input type='text' name='maa' size='30' value='{$row['maa']}'></td>
            </tr>
          </table>
        <input type='submit' name='action' value='Save changes' class="buttons" id="updateButton" onclick="javascript: return confirm('Update artist {$row['nimi']} ?')">
        <input type='submit' name='action' value='Delete artist' class="buttons" id="deleteButton" onclick="javascript: return confirm('Delete artist {$row['nimi']} ?')"><br>
      </form>
    </div>  
FORMEND;
echo $form;
}

include ("footer.php"); 

?>
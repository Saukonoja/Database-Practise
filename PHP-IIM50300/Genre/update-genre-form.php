<?php 
include ("../Init/header.php"); 

require_once($dbInit);

$id = $_POST['ID'];



$sql = "SELECT genre.nimi, genre.avain as id FROM genre WHERE avain = $id;";
$result = $conn->query("$sql");

if ($row = $result->fetch_assoc()){
  ?>
    <form action='<?php echo $genres ?>'><button id='btnBack' class='buttons'><i id="backIcon" class="fa fa-arrow-left fa-lg"></i></button></form>
    <div id="updateForm">
      <h1>Update genre</h1>
      <form method='post' action='update-genre.php'>
          <table border='0' cellpadding='5'>
            <tr id='hiddenTr' valign='top'>
              <td align='right'>ID</td>
              <td><?php echo $row['id']?><input type='hidden' name='id' size='30' value='<?php echo $row['id']?>'></td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Name</td>
              <td><input type='text' name='nimi' size='30' value='<?php echo $row['nimi']?>'></td>
            </tr>
          </table>
        <input type='submit' name='action' value='Save changes' class='buttons' id='updateButton' onclick="javascript: return confirm('Update genre <?php echo $row['nimi'] ?> ?')">
        <input type='submit' name='action' value='Delete genre' class="buttons" id="deleteButton" onclick="javascript: return confirm('Delete genre <?php echo $row['nimi'] ?> ?')"><br>
      </form>
    </div>  
 <?php   
}
include ($footer); 

?>
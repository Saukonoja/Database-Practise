<?php 

include ("../Init/header.php"); 

require_once($dbInit);

$_SESSION['id'] = $_POST['ID'];

include($userUpdateFormQuery);
$result = $conn->query("$sql");

if ($row = $result->fetch_assoc()){
  ?>
    <form action='<?php echo $users ?>'><button id='btnBack' class='buttons'><i id="backIcon" class="fa fa-arrow-left fa-lg"></i></button></form>
    <div id="updateForm">
      <h1>Update user</h1>
      <form method='post' action='<?php echo $updateUser ?>'>
          <table border='0' cellpadding='5'>
            <tr id='hiddenTr' valign='top'>
              <td align='right'>ID</td>
              <td><?php echo $row['ID']?><input type='hidden' name='id' size='30' value='<?php echo $row['ID']?>'></td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Username</td>
              <td><input type='text' name='username' size='30' value='<?php echo $row['username']?>'></td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Admin</td>
              <td>

                <?php
                  if($row['admin'] == 1){
                    $checked = "checked";
                  }else{
                    $checked = "";
                  }

                ?>

                 <input type="checkbox" id="checkBox" name="admin" <?php echo $checked; ?>>
              </td>
            </tr>
          </table>
        <input type='submit' name='action' value='Save changes' class="buttons" id="updateButton" onclick="javascript: return confirm('Update user <?php echo $row['username'] ?> ?')">
        <input type='submit' name='action' value='Delete user' class="buttons" id="deleteButton" onclick="javascript: return confirm('Delete user <?php echo $row['username'] ?> ?')">
      </form>
    </div>  
 <?php   
}
include ($footer); 

?>
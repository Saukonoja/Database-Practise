<?php

include("../Init/header.php");

require_once($userClass);

$_SESSION['current'] = "Users";

if (isset($_SESSION['islogged'])){
  if ($_SESSION['userType'] == 1){
      $displayUserType = "display:default";
  }else{
      $displayUserType = "display:none;";
  }
}else{
  $displayUserType = "display:none;";
}

echo '<div id="errorMessageContainer">
     	<div id=errorMessage>'.$error.'</div>
   	 </div>';
echo '<h1 id="pageHeader" style="'.$display.'">Users</h1>';

require_once($dbInit);
include($allUsersQuery);

?>
<div id="changePass" style="<?php echo $display ?>"><form method="post" action="<?php echo $changePassword ?>">
                <h3>Change password:</h3>
                New password:<br><input type="password" autofocus name="password"><br>
                Re-enter new password:<br><input type="password" name="re-password"><br>
                <input type="submit" name="action" value="Change password" class="buttons" id="updateButton" onclick="javascript: return confirm('Change password?')">
       	   </form>
      </div> 
<?php

$result = $conn->prepare($sql);
$result->execute();

if ($result->bind_result($username, $admin, $id)) {
 
    echo '<table class="query" style='. $displayUserType. '>';
    echo '<tr><th><a href="?sort=username&sort_by='.$sort_order.'" id="headerLink">Username</a></th>
              <th><a href="?sort=admin&sort_by='.$sort_order.'" id="headerLink">Admin</a></th>
              <th id= \'hiddenTh\'>ID</th></tr>';
    while($result->fetch()) {
        $newUser = new User($username, $admin, $id);
        echo $newUser;
    }
    echo '</table>';
} else {
    echo "0 results";
}
 
$conn->close();

include($footer);

?>
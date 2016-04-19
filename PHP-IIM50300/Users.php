<?php

include("header.php");

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

if ($_SESSION['userType']){
  $display = "display:default;";
}else{
  $display = "display:none;";
}

$_SESSION['current'] = "Artists";
echo '<div id="errorMessageContainer">
     	<div id=errorMessage>'.$error.'</div>
   	 </div>';
echo '<h1 id="pageHeader">Users</h1>';

require_once("db-init-music.php");
include("select-queries/all-users-query.php");

?>
<div id="changePass"><form method="post" action="change-password.php">
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
 
    echo '<table class="query" style='. $display. '>';
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

include("footer.php");

?>
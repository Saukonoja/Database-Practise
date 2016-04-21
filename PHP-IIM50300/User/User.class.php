<?php
 
    class User{
        private $username;
        private $admin;
        private $id;
 
        function __construct($username, $admin, $id){
            $this->username = $username;
            $this->admin = $admin;
            $this->id = $id;
        }

        function __toString() {
            include("../Init/config.php");
            if ($_SESSION['islogged'] == true){
                $display = 'display:default;';
            }    
            else{
                $display = 'display:none;';
            }

            return '<tr><td id=username>' .$this->username.'</td><td id=admin>' .$this->admin.'</td>
            </td><td id=\'editTd\'><form method=\'post\' action='.$updateUserForm.'><button style=' . $display . ' id=\'btnEdit\' name=\'ID\' value=' . $this->id . '>Edit</button></form></td></tr>';      
        }
    }
 
?>
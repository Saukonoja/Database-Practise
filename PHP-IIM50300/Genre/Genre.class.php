<?php
 
    class Genre{
        private $name;
        private $id;
 
        function __construct($name, $id){
            $this->name = $name;
            $this->id = $id;
        }

        function __toString() {
        	 include ("../Init/config.php");
            if ($_SESSION['islogged'] == true){
                $display = 'display:default;';
            }    
            else{
                $display = 'display:none;';
            }
            return "<tr><td><a href='" . $genrePage . "?link_genre=".$this->name."'>" . $this->name. '</a></td>
            <td id=\'editTd\'><form method=\'post\' action=\'update-genre-form.php\'><button style='. $display .
              ' id=\'btnEdit\' name=\'ID\' value=' . $this->id . '>Edit</button></form></td></tr>';
        }
    }
 
?>
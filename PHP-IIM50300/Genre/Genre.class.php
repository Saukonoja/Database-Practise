<?php
 
    class Genre{
        private $name;
 
        function __construct($name){
            $this->name = $name;
        }

        function __toString() {
        	include("../Init/config.php");
            return "<tr><td><a href='" . $genrePage . "?link_genre=".$this->name."'>" . $this->name. '</a></td></tr>';
        }
    }
 
?>
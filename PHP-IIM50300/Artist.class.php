<?php
 
    class Artist{
        private $name;
        private $year;
        private $country;
 
        function __construct($name, $year, $country){
            $this->name = $name;
            $this->year = $year;
            $this->country = $country;
        }

        function __toString() {
            return "<tr><td><a href='artist-page.php?link_artist=".$this->name."'>" . $this->name. '</a></td><td>' . $this->year. '</td><td>' . $this->country . '</td></tr>';
        }
    }
 
?>
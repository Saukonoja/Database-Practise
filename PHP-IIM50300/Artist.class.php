<?php
 
    class Artist{
        private $name;
        private $year;
        private $country;
        private $id;
 
        function __construct($name, $year, $country, $id){
            $this->name = $name;
            $this->year = $year;
            $this->country = $country;
            $this->id = $id;
        }

        function __toString() {
            return "<tr><td><a href='artist-page.php?link_artist=".$this->name."'>" 
            . $this->name. '</a></td><td id=year>' . $this->year. '</td><td id=country>' . $this->country .
             '</td><td id=\'editTd\'><form method=\'post\' action=\'update-artist-form.php\'><button id=btnEdit name=\'ID\' value=' . $this->id . '>Edit</button></form></td></tr>';
        }
    }
 
?>



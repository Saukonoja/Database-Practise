<?php
 
    class Album{
        private $name;
        private $artist;
        private $year;
        private $company;
 
        function __construct($name, $artist, $year, $company){
            $this->name = $name;
            $this->artist = $artist;
            $this->year = $year;
            $this->company = $company;
        }

        function __toString() {
            return "<tr><td><a href='album-page.php?link_album=".$this->name."'>" . $this->name. "</a></td><td><a href='artist-page.php?link_artist=".$this->artist."'>" . $this->artist. "</a></td>
                        <td id=year>". $this->year . "</td><td><a href='company-page.php?link_company=".$this->company."'>" . $this->company. "</a></td></tr>";
        }
    }
 
?>
<?php
 
    class AlbumView{
        private $number;
        private $track;
        private $length;
 
        function __construct($number, $track, $length){
            $this->number = $number;
            $this->track = $track;
            $this->length = $length;
        }

        function __toString() {
            include("../Init/config.php");
            return '<tr><td id=number>' . $this->number. "</td><td id=track><a href='" . $albumPage . "?link_track=". htmlspecialchars($this->track, ENT_QUOTES)."'>" . $this->track. '</td><td id=length>' 
            . $this->length. '</td>'; 
        }

        function albumInfo($artist, $year, $row_count, $length){
            include("../Init/config.php");
            return "<p id='albumInfo'>from artist <span id='artist'><a href='" . $artistPage . "?link_artist=". $artist."'>" . $artist. '</a></span> &#9679; ' .$year. ' &#9679; ' .$row_count. ' tracks, '
            . $length.'</p>';
        }

        function youtubeVideo($tube){
            return "<iframe width='700' height='400' src='http://www.youtube.com/embed/".$tube."?rel=0&amp;hd=1&amp;autoplay=1' frameborder='0' allowfullscreen></iframe>";
        }
        
    }
 
?>
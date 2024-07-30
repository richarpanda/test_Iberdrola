SELECT 
     a.AuthorName
    ,d.DoctorName
    ,COUNT(e.EpisodeId) AS Episodes
FROM tblEpisode e
INNER JOIN tblAuthor a ON e.AuthorId = a.AuthorId
INNER JOIN tblDoctor d ON e.DoctorId = d.DoctorId
GROUP BY a.AuthorName, d.DoctorName
ORDER BY Episodes DESC, a.AuthorName






select b.BookID, b.Bookname, b.BookPrice, b.PublicationDate,STRING_AGG(a.AuthorName,',') as AuthorsName  from Authors a join AuthorBooks ab on a.AuthorBookId = ab.AuthorId
join Books b on ab.BookId = b.AuthorBookId
group by b.BookID, b.BookPrice, b.PublicationDate, b.Bookname
go


create or alter procedure usp_Booksdata
as
select b.BookID, b.Bookname, b.BookPrice, b.PublicationDate,STRING_AGG(a.AuthorName,',') as AuthorsName  from Authors a join AuthorBooks ab on a.AuthorBookId = ab.AuthorId
join Books b on ab.BookId = b.AuthorBookId
group by b.BookID, b.BookPrice, b.PublicationDate, b.Bookname
go

exec usp_Booksdata 


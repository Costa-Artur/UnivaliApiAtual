using Microsoft.EntityFrameworkCore;
using Univali.Api.DbContexts;
using Univali.Api.Entities;
using Univali.Api.Features.Common;
using Univali.Api.Models;


namespace Univali.Api.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly PublisherContext _context;

    public PublisherRepository(PublisherContext context)
    {
        _context = context;
    }

    public async Task<Publisher?> GetPublisherByIdAsync(int publisherId)
    {
        return await _context.Publishers.FirstOrDefaultAsync(p => p.PublisherId == publisherId);
    }

    public async Task<Publisher?> GetPublisherWithCoursesByIdAsync(int publisherId)
    {
        return await _context.Publishers.Include(p => p.Courses).FirstOrDefaultAsync(p => p.PublisherId == publisherId);
    }

    public async Task<IEnumerable<Publisher>> GetPublishersAsync()
    {
        return await _context.Publishers.OrderBy(p => p.PublisherId).ToListAsync();
    }

    public void AddPublisher(Publisher publisher)
    {
        _context.Publishers.Add(publisher);
    }

    public void UpdatePublisher(Publisher publisher)
    {
        _context.Publishers.Update(publisher);
    }

    public void RemovePublisher(Publisher publisher)
    {
        _context.Publishers.Remove(publisher);
    }

    public async Task<Course?> GetCourseByIdAsync(int courseId)
    {
        return await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
    }

    public async Task<Course?> GetCourseWithAuthorsByIdAsync(int courseId)
    {
        return await _context.Courses
            .Include(c => c.Authors)
            .FirstOrDefaultAsync(c => c.CourseId == courseId);
    }

    public async Task<bool> PublisherExistsAsync(int publisherId)
    {
       return await _context.Publishers
            .AnyAsync(publisher => publisher.PublisherId == publisherId);
    }

    public async Task AddCourseAsync(int publisherId, Course course)
    {
        var publisher = await GetPublisherByIdAsync(publisherId);

        publisher?.Courses.Add(course);
    }

    public void UpdateCourse(Course course)
    {
        // var c = new Course("first title", 5,"some description");

        // _publisherContext.Courses.Add(c);

        _context.Courses.Update(course);
    }

    public void DeleteCourse(int courseId)
    {
        var courseEntity = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);

        if (courseEntity == null) return;

        _context.Courses.Remove(courseEntity);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<(IEnumerable<Course>, PaginationMetadata)> GetCoursesAsync(string? category, string? searchQuery, int pageNumber, int pageSize)
    {
       

        var collection = _context.Courses as IQueryable<Course>;

        if(!string.IsNullOrWhiteSpace(category))
        {
            category = category.Trim();
            collection = collection.Where(c => c.Category == category);
        }

        if(!string.IsNullOrWhiteSpace(searchQuery))
        {
            searchQuery = searchQuery.Trim();
            collection = collection.Where(c => c.Category.Contains(searchQuery)
                || c.Title.Contains(searchQuery)
                || c.Description.Contains(searchQuery));
        }

        var totalItemCount = await collection.CountAsync();

        var paginationMetadata = new PaginationMetadata (totalItemCount, pageSize, pageNumber);

        var coursesToReturn = await collection
            .OrderBy(c => c.CourseId)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (coursesToReturn, paginationMetadata);    
    }

    public async Task<Author?> FindAuthorAsync(int id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task<List<Author>> GetAuthorsById(IEnumerable<int> authorIds)
    {
        return await _context.Authors.Where(a => authorIds.Contains(a.AuthorId)).ToListAsync();
        // var existingAuthors = _context.Authors.Where(a => authorIds.Any(id => id == a.Id)).ToList();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Author?> GetAuthorByIdAsync(int AuthorId)
    {
        return await _context.Authors.FirstOrDefaultAsync(author => author.AuthorId == AuthorId);
    }

    public async Task<Author?> GetAuthorWithCoursesByIdAsync(int authorId)
    {
        return await _context.Authors.Include(a => a.Courses).FirstOrDefaultAsync(author => author.AuthorId == authorId);
    }

    public void AddAuthor(Author author)
    {
        _context.Authors.Add(author);
    }
    public void UpdateAuthor(Author author)
    {
        _context.Authors.Update(author);
    }
    public void DeleteAuthor(Author author)
    {
        
        _context.Authors.Remove(author);

    }


    public async Task<IEnumerable<Question>> GetQuestionsByStudentIdAsync(int studentId)
    {
        return await _context.Questions.Where(q => q.StudentId == studentId).OrderBy(q => q.QuestionId).ToListAsync();
    }

    public async Task<IEnumerable<Question>> GetQuestionsByLessonIdAsync(int lessonId)
    {
        return await _context.Questions.Where(q => q.LessonId == lessonId).OrderBy(q => q.QuestionId).ToListAsync();
    }

    public async Task<IEnumerable<Question>> GetQuestionsAsync(int studentId, string? category, string? searchQuery)
    {
        if(string.IsNullOrWhiteSpace(category) && string.IsNullOrWhiteSpace(searchQuery)) return await GetQuestionsByStudentIdAsync(studentId);

        var collection = _context.Questions as IQueryable<Question>;

        if(!string.IsNullOrWhiteSpace(category))
        {
            category = category.Trim();
            collection = collection.Where(c => c.Category == category);
        }

        if(!string.IsNullOrWhiteSpace(searchQuery))
        {
            searchQuery = searchQuery.Trim();
            collection = collection.Where(c => c.Category.Contains(searchQuery)
                || c.Questioning.Contains(searchQuery));
        }

        return await collection.ToListAsync();
    }


    public async Task<Question?> GetQuestionByIdAsync(int questionId)
    {
        return await _context.Questions.FirstOrDefaultAsync(question => question.QuestionId == questionId);
    }

    public async Task<Question?> GetQuestionWithAnswersByIdAsync(int questionId)
    {
        return await _context.Questions.Include(q => q.Answers).FirstOrDefaultAsync(question => question.QuestionId == questionId);
    }

    public void AddQuestion(Question question)
    {
        _context.Questions.Add(question);
    }

    public void DeleteQuestion(Question question)
    {
        _context.Questions.Remove(question);
    }

    public async Task<bool> LessonExistsAsync(int lessonId)
    {
        return await _context.Lessons
            .AnyAsync(c => c.LessonId == lessonId);
    }
    public async Task<bool> StudentExistsAsync(int studentId)
    {
        return await _context.Students
            .AnyAsync(s => s.StudentId == studentId);
    }

    // public async Task<bool> LessonExistAsync(int lessonId)
    // {
    //     var lessonEntity = await GetLessonByIdAsync(lessonId);
    //     if (lessonEntity != null){
    //         _context.Entry(lessonEntity).State = EntityState.Detached;
    //         return true;
    //     }
    //     return false;
    // }

    public async Task<Lesson?> GetLessonByIdAsync(int lessonId)
    {
        return await _context.Lessons.FirstOrDefaultAsync(c => c.LessonId == lessonId);
    }

    public void CreateLesson(Lesson lessonEntity)
    {
        _context.Lessons.Add(lessonEntity);
    }

    public void UpdateLesson(Lesson lessonEntity)
    {
        _context.Lessons.Update(lessonEntity);
    }

    public void DeleteLesson(Lesson lessonEntity)
    {
        _context.Lessons.Remove(lessonEntity);
    }

    public async Task<IEnumerable<Lesson>?> GetLessonsAsync()
    {
        return await _context.Lessons.OrderBy(c => c.LessonId).ToListAsync();
    }

    public async Task<bool> ModuleExistsAsync(int moduleId)
    {
        return await _context.Modules.FindAsync(moduleId) != null;
    }


    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return await _context.Students.OrderBy(c => c.StudentId).ToListAsync();
    }

    public async Task<IEnumerable<Student>> GetStudentsWithQuestionsAsync()
    {
        return await _context.Students.Include(c => c.Questions).OrderBy(c => c.StudentId).ToListAsync();
    }

    public async Task<IEnumerable<Student>> GetStudentCollectionAsync(string? name, string? cpf, string? searchQuery)
    {
        if(string.IsNullOrWhiteSpace(name) 
            && string.IsNullOrWhiteSpace(cpf)
            && string.IsNullOrWhiteSpace(searchQuery))
            return await GetStudentsAsync();

        var collection = _context.Students as IQueryable<Student>;

        if(!string.IsNullOrWhiteSpace(name))
        {
            name = name.Trim();
            collection = collection.Where(s => s.Name == name);
        }

        if(!string.IsNullOrWhiteSpace(cpf))
        {
            cpf = cpf.Trim();
            collection = collection.Where(s => s.CPF == cpf);
        }

        if(!string.IsNullOrWhiteSpace(searchQuery))
        {
            name = searchQuery.Trim();
            collection = collection.Where(s => s.Name.Contains(searchQuery)
                || s.CPF.Contains(searchQuery));
        }

        return await collection.ToListAsync();
    }

    public void RemoveStudent(Student student)
    {
        _context.Students.Remove(student);
    }
    public void UpdateStudent(Student student)
    {
        _context.Students.Update(student);
    }

    public async Task<Student?> GetStudentByIdAsync(int studentId)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
    }

    public void AddAnswer(Answer answer)
    {
        _context.Answers.Add(answer);
    }

    public void DeleteAnswer(Answer answer)
    {
        _context.Answers.Remove(answer);
    }

    public async Task<Answer?> GetAnswerByIdAsync(int answerId)
    {
        return await _context.Answers.FirstOrDefaultAsync(a => a.AnswerId == answerId);
    }

    public async Task<(IEnumerable<Answer>, PaginationMetadata)> GetAnswersAsync(int questionId, int pageNumber, int pageSize)
    {
        var collection = _context.Answers.Where(a => a.QuestionId == questionId).OrderBy(a => a.AnswerId);

        var totalItemCount = await collection.CountAsync();

        var paginationMetadata = new PaginationMetadata (totalItemCount, pageSize, pageNumber);

        var answersToReturn = await collection
            .OrderBy(c => c.AnswerId)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (answersToReturn, paginationMetadata); 
    }

    public async Task<(IEnumerable<Answer>,PaginationMetadata)> GetAnswersAsync(int authorId, string? searchQuery, int pageNumber, int pageSize)
    {
        var collection = _context.Answers
         as IQueryable<Answer>;

        if(string.IsNullOrWhiteSpace(searchQuery)) collection = collection.Where(a => a.AuthorId == authorId);

        if(!string.IsNullOrWhiteSpace(searchQuery))
        {
            searchQuery = searchQuery.Trim();
            collection = collection.Where(c => c.Body.Contains(searchQuery));
        }

        var totalItemCount = await collection.CountAsync();

        var paginationMetadata = new PaginationMetadata (totalItemCount, pageSize, pageNumber);

        var answersToReturn = await collection
            .OrderBy(c => c.AnswerId)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (answersToReturn, paginationMetadata);  
    }

    public async Task<bool> QuestionExistsAsync(int questionId)
    {
        return await _context.Questions
            .AnyAsync(q => q.QuestionId == questionId);
    }

    public async Task<bool> AuthorExistsAsync(int authorId)
    {
        return await _context.Authors
            .AnyAsync(a => a.AuthorId == authorId);
    }

    public async Task<bool> AnswerExistsAsync(int answerId)
    {
        return await _context.Answers
            .AnyAsync(a => a.AnswerId == answerId);
    }
}
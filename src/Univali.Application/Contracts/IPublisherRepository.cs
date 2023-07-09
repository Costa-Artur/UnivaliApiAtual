using Univali.Api.Entities;
using Univali.Api.Features.Common;

namespace Univali.Api.Repositories;

public interface IPublisherRepository
{
    Task<IEnumerable<Publisher>> GetPublishersAsync();
    Task<Publisher?> GetPublisherByIdAsync(int publisherId);
    public Task<Publisher?> GetPublisherWithCoursesByIdAsync(int publisherId);
    void AddPublisher(Publisher publisher);
    public void UpdatePublisher(Publisher publisher);
    void RemovePublisher(Publisher publisher);
    Task<bool> PublisherExistsAsync(int publisherId);
    public Task<Course?> GetCourseByIdAsync(int courseId);
    public Task<Course?> GetCourseWithAuthorsByIdAsync(int courseId);
    public Task AddCourseAsync(int publisherId, Course course);
    public void UpdateCourse(Course course);
    public void DeleteCourse(int courseId);

    Task<IEnumerable<Course>> GetCoursesAsync();
    //Task<(IEnumerable<Course>, PaginationMetadata)> GetCoursesAsync(string? category, string? searchQuery, int pageNumber, int pageSize);

    Task<bool> SaveChangesAsync();
    Task<Author?> FindAuthorAsync(int id);
    Task<List<Author>> GetAuthorsById(IEnumerable<int> authorIds);
    public Task<Author?> GetAuthorByIdAsync(int authorId);
    public Task<Author?> GetAuthorWithCoursesByIdAsync(int authorId);
    public void AddAuthor(Author author);
    public void UpdateAuthor(Author author);
    public void DeleteAuthor(Author author);
    Task<bool> AuthorExistsAsync(int authorId);


    Task<IEnumerable<Question>> GetQuestionsByStudentIdAsync(int studentId);
    Task<IEnumerable<Question>> GetQuestionsByLessonIdAsync(int lessonId);
    Task<IEnumerable<Question>> GetQuestionsAsync(int studentId, string? category, string? searchQuery);
    public Task<Question?> GetQuestionByIdAsync(int questionId);
    public Task<Question?> GetQuestionWithAnswersByIdAsync(int questionId);
    public void AddQuestion(Question question);
    public void DeleteQuestion(Question question);
    Task<bool> StudentExistsAsync(int studentId);

    Task<bool> ModuleExistsAsync(int moduleId);
    Task<bool> LessonExistsAsync(int lessonId);
    Task<Lesson?> GetLessonByIdAsync(int lessonId);
    Task<IEnumerable<Lesson>?> GetLessonsAsync();
    void CreateLesson(Lesson lessonEntity);
    void UpdateLesson(Lesson lessonEntity);
    void DeleteLesson(Lesson lessonEntity);

    void AddStudent(Student student);
    Task<IEnumerable<Student>> GetStudentsAsync();
    Task<IEnumerable<Student>> GetStudentsWithQuestionsAsync();
    Task<Student?> GetStudentByIdAsync(int studentId);
    Task<IEnumerable<Student>> GetStudentCollectionAsync(string? name, string? cpf, string? searchQuery);

    void UpdateStudent(Student student);
    void RemoveStudent(Student student);

    void AddAnswer(Answer answer);
    void DeleteAnswer(Answer answer);
    Task<Answer?> GetAnswerByIdAsync(int answerId);
    Task<(IEnumerable<Answer>, PaginationMetadata)> GetAnswersAsync(int questionId, int pageNumber, int pageSize);
    Task<(IEnumerable<Answer>, PaginationMetadata)> GetAnswersAsync(int authorId, string? searchQuery, int pageNumber, int pageSize);
    Task<bool> QuestionExistsAsync(int questionId);

    Task<bool> AnswerExistsAsync(int answerId);
}
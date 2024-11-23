namespace BicycleRent.Server.Services;

/// <summary>
/// Interface for object's service
/// </summary>
/// <typeparam name="TDto">DTO type</typeparam>
/// <typeparam name="TKey">Key type</typeparam>
public interface IService<TDto, TKey>
{
    /// <summary>
    /// Get all elements of TDto
    /// </summary>
    /// <returns>List of elements</returns>
    public IEnumerable<TDto> GetAll();

    /// <summary>
    /// Get a object of TDto by id
    /// </summary>
    /// <param name="id">Object's id</param>
    /// <returns>Object's information or null</returns>
    public TDto? GetById(TKey id);

    /// <summary>
    /// Post object's information to database
    /// </summary>
    /// <param name="dtoData">The data to add</param>
    public void Add(TDto dtoData);

    /// <summary>
    /// Update object's information by id
    /// </summary>
    /// <param name="dtoData">Object's information to update</param>
    /// <param name="id">The id of the object to update</param>
    /// <returns>True or False</returns>
    public bool Update(TDto dtoData, TKey id);

    /// <summary>
    /// Deletes an element from the collection by id
    /// </summary>
    /// <param name="id">The id of the object to delete</param>
    /// <returns>True or False</returns>
    public bool Delete(TKey id);
}


﻿using Issues.Manager.Application.Abstractions.RepositoryContracts;

namespace Issues.Manager.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly AppDbContext _dbContext;
    private IIssueRepository? _issueRepository;
    private IUserRepository? _userRepository;
    private ICommentsRepository _commentsRepository;

    public RepositoryManager(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICommentsRepository Comment
    {
        get
        {
            if (_commentsRepository == null)
            {
                _commentsRepository = new CommentRepository(_dbContext);
            }

            return _commentsRepository;
        }
        
    }

    public IIssueRepository Issue
    {
        get
        {
            if (_issueRepository == null)
            {
                _issueRepository = new IssueRepository(_dbContext);
            }


            return _issueRepository;
        }
    }

    public IUserRepository User
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_dbContext);
            }

            return _userRepository;
        }
    }
    
    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}
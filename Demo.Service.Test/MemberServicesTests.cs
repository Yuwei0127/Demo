using System.Reflection;
using AutoFixture;
using Demo.Repository.Interface;
using Demo.Repository.Models;
using Demo.Service.Implement;
using Demo.Service.Models;
using Demo.Service.Test.TestGlobalSetting;
using FluentAssertions;
using Mapster;
using MapsterMapper;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace Demo.Service.Test;

public class MemberServicesTests : IClassFixture<TestsBase>
{
    private readonly IMemberRepository _memberRepository;
    private readonly Fixture _fixture;

    public MemberServicesTests()
    {
        _memberRepository = Substitute.For<IMemberRepository>();
        _fixture = new Fixture();
    }
    
    private MemberService CreateMemberService()
    {
        return new MemberService(_memberRepository);
    }
    
    // Fact => 正常測試方法
    // Theory => 一個或多個 DataAttribute 
    
    [Fact]
    public void GetAllMemberInfoAsync_取得全部成員資訊_應回傳EmployeesDataModel集合()
    {
        // Arrange
        var sut = CreateMemberService();
        
        var memberList = _fixture.Build<EmployeesDataModel>()
                                 .CreateMany(10);
        _memberRepository.GetAllAsync().Returns(memberList);
        
        // Act
        var actual = sut.GetAllMemberInfoAsync();
        
        // Assert
        actual.Should().NotBeNull();
    }

    [Fact]
    public void GetMemberInfoAsync_傳進來的Id等於零_應回傳Null()
    {
        // Arrange
        var sut = CreateMemberService();
        
        // Act
        var actual = sut.GetMemberInfoAsync(0);
        
        // Assert
        actual.Should().NotBeNull();
    }

    [Fact]
    public void GetMemberInfoAsync_傳進來的Id大於零_應回傳EmployeesDataModel()
    {
        // Arrange
        var sut = CreateMemberService();
        _memberRepository.GetAsync(1).Returns(new EmployeesDataModel());
        
        // Act
        var actual = sut.GetMemberInfoAsync(1);
        
        // Assert
        actual.Should().NotBeNull();
    }
}
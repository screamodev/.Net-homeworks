using System.Threading;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.UnitTests.Services;

public class CatalogBrandServiceTest
{
    private readonly ICatalogBrandService _catalogBrandService;

    private readonly Mock<IRepository<CatalogBrand, CatalogBrandCreateDto, CatalogBrandUpdateDto>> _catalogBrandRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly int _testId = 1;

    private readonly CatalogBrandCreateDto _catalogBrandCreateDto = new CatalogBrandCreateDto()
    {
        Brand = "Gucci"
    };

    private readonly CatalogBrandUpdateDto _catalogBrandUpdateDto = new CatalogBrandUpdateDto()
    {
        Brand = "Gucci"
    };

    private readonly CatalogBrandDto _catalogBrandDtoSuccess = new CatalogBrandDto()
    {
        Brand = "Gucci"
    };

    private readonly CatalogBrand _catalogBrandSuccess = new CatalogBrand()
    {
        Brand = "Gucci"
    };

    public CatalogBrandServiceTest()
    {
        _catalogBrandRepository = new Mock<IRepository<CatalogBrand, CatalogBrandCreateDto, CatalogBrandUpdateDto>>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _catalogBrandService = new CatalogBrandService(_dbContextWrapper.Object, _logger.Object, _catalogBrandRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task GetAllAsync_Success()
    {
        var catalogBrandsSuccess = new List<CatalogBrand>()
        {
            new CatalogBrand()
            {
                Brand = "Gucci",
            },
        };

        _catalogBrandRepository.Setup(s => s.GetAllAsync())
            .ReturnsAsync(catalogBrandsSuccess);

        _mapper.Setup(s => s.Map<CatalogBrandDto>(
            It.Is<CatalogBrand>(i => i.Equals(_catalogBrandSuccess)))).Returns(_catalogBrandDtoSuccess);

        // act
        var result = await _catalogBrandService.GetBrandsAsync();

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAllAsync_Failed()
    {
        // arrange
        List<CatalogBrand> testResult = new List<CatalogBrand>();

        _catalogBrandRepository.Setup(s => s.GetAllAsync())
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.GetBrandsAsync();

        // assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        // arrange
        _catalogBrandRepository.Setup(s => s.AddAsync(
            It.IsAny<CatalogBrandCreateDto>())).ReturnsAsync(_catalogBrandSuccess);

        _mapper.Setup(s => s.Map<CatalogBrandDto>(
            It.Is<CatalogBrand>(i => i.Equals(_catalogBrandSuccess)))).Returns(_catalogBrandDtoSuccess);

        // act
        var result = await _catalogBrandService.AddBrandAsync(_catalogBrandCreateDto);

        // assert
        result.Should().NotBeNull();
        result?.Brand.Should().Be(_catalogBrandDtoSuccess.Brand);
        result?.Id.Should().Be(_catalogBrandDtoSuccess.Id);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        // arrange
        CatalogBrand? testResult = null;

        _catalogBrandRepository.Setup(s => s.AddAsync(
            It.IsAny<CatalogBrandCreateDto>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.AddBrandAsync(_catalogBrandCreateDto);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        // arrange
        _catalogBrandRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<CatalogBrandUpdateDto>())).ReturnsAsync(_catalogBrandSuccess);

        _mapper.Setup(s => s.Map<CatalogBrandDto>(
            It.Is<CatalogBrand>(i => i.Equals(_catalogBrandSuccess)))).Returns(_catalogBrandDtoSuccess);

        // act
        var result = await _catalogBrandService.UpdateBrandAsync(_testId, _catalogBrandUpdateDto);

        // assert
        result.Should().NotBeNull();
        result?.Brand.Should().Be(_catalogBrandDtoSuccess.Brand);
        result?.Id.Should().Be(_catalogBrandDtoSuccess.Id);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        // arrange
        CatalogBrand? testResult = null;

        _catalogBrandRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<CatalogBrandUpdateDto>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.UpdateBrandAsync(_testId, _catalogBrandUpdateDto);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteAsync_Success()
    {
        // arrange
        _catalogBrandRepository.Setup(s => s.DeleteAsync(
            It.IsAny<int>())).ReturnsAsync(true);

        // act
        var result = await _catalogBrandService.DeleteBrandAsync(_testId);

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        // arrange
        bool? testResult = null;

        _catalogBrandRepository.Setup(s => s.DeleteAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.DeleteBrandAsync(_testId);

        // assert
        result.Should().BeNull();
    }
}
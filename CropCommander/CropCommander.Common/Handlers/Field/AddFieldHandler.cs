using CropCommander.Common.Commands;
using CropCommander.Common.DataAccess;
using MediatR;
using FluentValidation;

namespace CropCommander.Common.Handlers.Field;

public class AddFieldHandler : IRequestHandler<AddFieldCommand, Models.Field>
{
    private readonly IDataAccess _dataAccess;
    private readonly IValidator<AddFieldCommand> _validator;
    
    public AddFieldHandler(IDataAccess dataAccess, IValidator<AddFieldCommand> validator)
    {
        _dataAccess = dataAccess;
        _validator = validator;
    }
    
    public async Task<Models.Field> Handle(AddFieldCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            // Handle validation failure, throw an exception or return a result
            throw new ValidationException(validationResult.Errors);
        }

        // Proceed with adding the field to the database if validation is successful
        return _dataAccess.AddField(request.FieldName, request.FieldArea, request.CropName);
    }

    public class AddFieldValidator : AbstractValidator<AddFieldCommand>
    {
        public AddFieldValidator(IDataAccess dataAccess)
        {
            RuleFor(x => x.FieldName)
                .NotEmpty().WithMessage("Field name must not be empty.")
                .MustAsync(async (fieldName, cancellation) => 
                    !await dataAccess.FieldNameExistsAsync(fieldName))
                .WithMessage("Field name must be unique.");

            RuleFor(x => x.CropName)
                .NotEmpty().WithMessage("Crop name is required.");

            RuleFor(x => x.FieldArea)
                .GreaterThan(0).WithMessage("Field area must be greater than 0.");
        }
    }
}